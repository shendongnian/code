            internal static void Do()
        {
            AsyncCallback cb = Complete;
            List<double[]> row = CreateList();
            for (int i = 0; i < 200; i++)
            {
                Func<double[], double> myMethod = Process;
                myMethod.BeginInvoke(row[i], cb, null);
            }
        }
        static double Process (double[] vals)
        {
           // your implementation
            return randy.NextDouble();
        }
        static void Complete(IAsyncResult token)
        {
            
            Func<double[], double> callBack = (Func<double[], double>)((AsyncResult)token).AsyncDelegate;
            double res = callBack.EndInvoke(token);
            Console.WriteLine("complete res {0}", res);
            DoSomething(res);
            
        }
