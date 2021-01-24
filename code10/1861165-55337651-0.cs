    public static int CalculateFee(int booksCheckedOut, int daysOverdue)
    {
       double libraryFine = .10;
       double additionalFine = .20;
       if (daysOverdue <= 7)
       {
          for (double x = 0; x <= 7; x++)
          {
             libraryFine += .10;
          }
          return Convert.ToInt32(libraryFine);
       }
       if (daysOverdue > 7)
       {
          for (int x =0; x<=daysOverdue; x++)
          {
             additionalFine += .20;
          }
          return Convert.ToInt32(additionalFine);
       }
    
      /// what does it do here!!!!
      return 34059834;
      // or
      throw new InvalidOperationException("woah didnt think id be here");
    }
