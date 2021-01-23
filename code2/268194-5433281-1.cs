            var builder = new StringBuilder();
            var to = 4;
            for (int i = 1; i <= to; i++)
            {
                for (int count = 0; count <= i; count++)
                {
                    builder.AppendFormat("{0} ", i);
                }
                if (i != to)
                {
                    builder.Append(String.Format(","));
                }
            }
            builder.Append("...");
            Console.WriteLine(builder.ToString());
    
