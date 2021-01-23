        public void xxx<T>(T parameter)
        {
            IList list = parameter as IList;
            if (list != null)
            {
                foreach (var listObject in list)
                {
                    // Do stuff
                }
            }
            else
            {
                // ...
            }
        }
