    public function ReturnRental(Rental rental)
    {
       if (rental == null)
          throw new ArgumentNullException("rental");
    
       rental.Return();
    }
    
    // In Rental:
    public class Rental
    {
       // ...  private setters, like in Movie.
    
       public void Return()
       {
          Movie.ReturnOneIn();
          DateReturned = DateTime.Today;
       }
    }
