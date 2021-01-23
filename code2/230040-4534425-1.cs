    class Booking
    {   
        //what other details do you need to save at the end?...
        public Show bookedShow { get; private set; }
        public Seat selectedSeat { get; private set; }
        public Show selectedShow { get; private set; }
        public Seat finalPrice { get; private set; } //hasnt been defined yet, but this would be the amount of seats selected * the Price
        //i will also need customer details which are:
        public dateAndTime dateTime { get; private set; }
        public Customer custName { get; private set; }
        public Customer custAddress { get; private set; }
        public Customer custTelephone { get; private set; }
        public void MyMethod()
        {
          System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\BookingInfo.txt"); //open the file for writing.               
          writer.Write(dateTime.ToString()); //write the current date to the file. change this with your date or something.
          writer.Write(bookedShow.ToString());
          writer.Write(selectedShow.ToString());
          writer.Write(selectedSeat.ToString());
          writer.Write(finalPrice.ToString());
          writer.Write(custName.ToString());
          writer.Write(custAddress.ToString());
          writer.Write(custTelephone.ToString());
          writer.Close();
        }
     }
