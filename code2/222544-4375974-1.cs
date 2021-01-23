    // For classes Customer, Account, Car
    Serra.CarRental.Domain;    
    // I use Dao as a general abbreviation for "Data Access Objects"
    // Dao interfaces go here:
    Serra.CarRental.Dao;     
    // Linq implementation for Dao interfaces  
    Serra.CarRental.Dao.Linq;
    // For Services specific to the car rental domain: 
    // AccountService and RentalService and CarAvailabilityService
    Serra.CarRental.Services;  
    // For UI objects (not relevant in you situation?)
    Serra.CarRental.UI;
    // general service code; ignorant of the CarRental domain (e.g. an EmailService)
    Serra.Infra.Service;       
