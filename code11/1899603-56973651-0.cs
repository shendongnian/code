    public class Assigner : IDisposable
    {
        private char _current;
        
        public bool CheckAndAssign(Predicate<string> condition, ref string sVar)
        {            
            if (condition(sVar))
            {
                if (_current == default(char))
                {
                    _current = 'A'                    
                }
                else
                {
                    _current++;
                }
                
                sVar = _current.ToString();
            }
            else
            {
                sVar = "None"
            }
        }
        
        public void Dispose()
        {
            _current = default(char);
        }
    }
    
