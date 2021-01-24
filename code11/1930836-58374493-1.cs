     public class Function : DoubleParameterizedFunction
        {
            public Function ()
            { }
            public override double Evaluate (DoubleVector p, double x)
            {
                double a = p[0];
                double b = p[1];
                double c = p[2];
                return a + c*Math.Sin(b + x) * Math.Sin(b + x);
            }
            public override void GradientWithRespectToParams (DoubleVector p,
              double x, ref DoubleVector grad)
            {
                double a = p[0];
                double b = p[1];
                double c = p[2];
                grad[0] = 1; //partial differential for a
                grad[1] = 2 * c * Math.Sin(x + b) * Math.Cos(x + b);  //partial differential for b
                grad[2] = Math.Sin(x + b) * Math.Sin(x + b);  //partial differential for c
            }
        }
