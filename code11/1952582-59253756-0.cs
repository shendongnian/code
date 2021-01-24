    public class Parent
    {
        public void ParentMethod()
        {
            try
            {
                var childClass = new Child();
                var process = childClass.Process();
                if (process)
                {
                    // Do this
                }
                else
                {
                    // raise new Exception
                }
            }
            catch (SqlException sqlEx)
            {
                WriteToErrorLogger.Error(ex);
            }
            catch(Exception ex){
                WriteToErrorLogger.Error(ex);
            }       
        }
    }
