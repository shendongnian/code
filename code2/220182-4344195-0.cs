        public class NumberBox : TextBox
        {
            public IList<Number> Numbers 
            {
                get
                {
                    List<Number> numbers = new List<Number>();
                    foreach (string line in Lines)
                    {
                        numbers.Add(new Number()
                        {
                            NumberText=line
                        });
                    }
                    return numbers;
                }
    
                set
                {
                    List<string> numberStrings = new List<string>();
                    foreach (Number n in value)
                    {
                        numberStrings.Add(n.NumberText);
                    }
                    this.Lines = numberStrings.ToArray();
                }
            }
        }
