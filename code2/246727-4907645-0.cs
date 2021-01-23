        public void MyMethod(object o)
        {
            if (o.GetType() == typeof(string))
            {
                //Do something if string
            }
            else if (o.GetType() == typeof(int))
            {
                // Do something else
            }
        }
