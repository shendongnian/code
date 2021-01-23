      class MyClass
      {
        Random random;
        public MyClass()
        {
          random = new Random(Guid.NewGuid().GetHashCode());
        }
    
        public void RandomNumber(int min, int max)
        {
          lblPickFive_1.Text = random.Next(min, max).ToString();      
        }
      }
