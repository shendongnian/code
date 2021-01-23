    Apartment newApartment = new Apartment();
    newApartment.Images.Add(new Image());
    newApartment.Images.Add(new Image());
    newApartment.Images.Add(new Image());
    newApartment.Images.Add(new Image());
    
    myDataContext.Apartments.Add(newApartment);
    myDataContext.SubmitChanges();
