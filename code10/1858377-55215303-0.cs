		public void x<T>(T obj)
        {
            //T is IEnumerable<object>
            //how to loop through T on compile time? 
            try
            {
                foreach (var item in (IEnumerable)obj)
                {
                    // Do what you want
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
