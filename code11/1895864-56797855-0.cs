            public int? MyMethod(string myString)
            {
                try
                {
                if (dataFromDB != null)
                {
                    return dataFromDB.Id;
                }
                catch (Exception myException)
                {
                    return null;
                }
            }
