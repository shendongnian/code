        public class TestNumbers
        {
            private int number = 0;
            public TestNumbers(int number)
            {
                this.number = number;
            }
            public override string ToString()
            {
                return "Test (" + number + ")";
            }
            public void Increment(int incrementStep)
            {
                number += incrementStep;
            }
            public int GetNumber()
            {
                return number;
            }
        }
