    public Booking()
    {
        	using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\BookingInfo.txt")) //open the file for writing.             
        	{ 
        	        writer.Write(dateTime.ToString()); //write the current date to the file. change this with your date or something.
        	        writer.Write(bookedShow.ToString());
        	        writer.Write(selectedShow.ToString());
        	        writer.Write(selectedSeat.ToString());
        	        writer.Write(finalPrice.ToString());
        	        writer.Write(custName.ToString());
        	        writer.Write(custAddress.ToString());
        	        writer.Write(custTelephone.ToString());
        	}
    }
