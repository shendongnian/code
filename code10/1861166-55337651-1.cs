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
       else
       {
          for (int x =0; x<=daysOverdue; x++)
          {
             additionalFine += .20;
          }
          return Convert.ToInt32(additionalFine);
       }
    }
