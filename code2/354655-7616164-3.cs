    namespace OperatorVsMethod
    {
      public struct Element
      {
        public double Left;
        public double Right;
    
        public Element(double left, double right)
        {
          this.Left = left;
          this.Right = right;
        }    
    
        public static Element operator +(Element x, Element y)
        {
          return new Element(x.Left + y.Left, x.Right + y.Right);
        }
        public static Element operator -(Element x, Element y)
        {
          x.Left += y.Left;
          x.Right += y.Right;
          return x;
        }    
    
        /// <summary>
        /// Like the += operator; but faster.
        /// </summary>
        public void PlusEqual(Element that)
        {
          this.Left += that.Left;
          this.Right += that.Right;
        }    
    
        /// <summary>
        /// Like the += operator; but faster.
        /// </summary>
        public void PlusEqual(double thatLeft, double thatRight)
        {
          this.Left += thatLeft;
          this.Right += thatRight;
        }    
      }    
    
      public class UnitTest1
      {
        public static void Main()
        {
          Stopwatch stopwatch = new Stopwatch();
    
          // Populate a List of Elements to multiply together
          int seedSize = 4;
          List<double> doubles = new List<double>(seedSize);
          doubles.Add(2.5d);
          doubles.Add(100000d);
          doubles.Add(-0.5d);
          doubles.Add(-100002d);
    
          int size = 10000000 * seedSize;
          List<Element> elts = new List<Element>(size);
    
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            int di = ii % seedSize;
            double d = doubles[di];
            elts.Add(new Element(d, d));
          }
          stopwatch.Stop();
          long populateMS = stopwatch.ElapsedMilliseconds;
    
          // Measure speed of += operator (calls ctor)
          Element operatorCtorResult = new Element(1d, 1d);
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            operatorCtorResult += elts[ii];
          }
          stopwatch.Stop();
          long operatorCtorMS = stopwatch.ElapsedMilliseconds;
    
          // Measure speed of -= operator (+= without ctor)
          Element operatorNoCtorResult = new Element(1d, 1d);
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            operatorNoCtorResult -= elts[ii];
          }
          stopwatch.Stop();
          long operatorNoCtorMS = stopwatch.ElapsedMilliseconds;
    
          // Measure speed of PlusEqual(Element) method
          Element plusEqualResult = new Element(1d, 1d);
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            plusEqualResult.PlusEqual(elts[ii]);
          }
          stopwatch.Stop();
          long plusEqualMS = stopwatch.ElapsedMilliseconds;
    
          // Measure speed of PlusEqual(double, double) method
          Element plusEqualDDResult = new Element(1d, 1d);
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            Element elt = elts[ii];
            plusEqualDDResult.PlusEqual(elt.Left, elt.Right);
          }
          stopwatch.Stop();
          long plusEqualDDMS = stopwatch.ElapsedMilliseconds;
    
          // Measure speed of doing nothing but accessing the Element
          Element doNothingResult = new Element(1d, 1d);
          stopwatch.Reset();
          stopwatch.Start();
          for (int ii = 0; ii < size; ++ii)
          {
            Element elt = elts[ii];
            double left = elt.Left;
            double right = elt.Right;
          }
          stopwatch.Stop();
          long doNothingMS = stopwatch.ElapsedMilliseconds;
    
          // Report speeds
          Console.WriteLine("Populating List<Element> took {0}ms.", populateMS);
          Console.WriteLine("The PlusEqual() method took {0}ms.", plusEqualMS);
          Console.WriteLine("The 'same' += operator took {0}ms.", operatorCtorMS);
          Console.WriteLine("The 'same' -= operator took {0}ms.", operatorNoCtorMS);
          Console.WriteLine("The PlusEqual(double, double) method took {0}ms.", plusEqualDDMS);
          Console.WriteLine("The do nothing loop took {0}ms.", doNothingMS);
    
          // Compare speeds
          long percentageRatio = 100L * operatorCtorMS / plusEqualMS;
          Console.WriteLine("The ratio of operator with constructor to method is {0}%.", percentageRatio);
          percentageRatio = 100L * operatorNoCtorMS / plusEqualMS;
          Console.WriteLine("The ratio of operator without constructor to method is {0}%.", percentageRatio);
          percentageRatio = 100L * plusEqualDDMS / plusEqualMS;
          Console.WriteLine("The ratio of PlusEqual(double,double) to PlusEqual(Element) is {0}%.", percentageRatio);
    
          operatorCtorMS -= doNothingMS;
          operatorNoCtorMS -= doNothingMS;
          plusEqualMS -= doNothingMS;
          plusEqualDDMS -= doNothingMS;
          Console.WriteLine("If we remove the overhead time for the loop accessing the elements from the List...");
          percentageRatio = 100L * operatorCtorMS / plusEqualMS;
          Console.WriteLine("The ratio of operator with constructor to method is {0}%.", percentageRatio);
          percentageRatio = 100L * operatorNoCtorMS / plusEqualMS;
          Console.WriteLine("The ratio of operator without constructor to method is {0}%.", percentageRatio);
          percentageRatio = 100L * plusEqualDDMS / plusEqualMS;
          Console.WriteLine("The ratio of PlusEqual(double,double) to PlusEqual(Element) is {0}%.", percentageRatio);
        }
      }
    }
