    using System;
    using System.Collections.Generic;
    
    public static class Program {
        public static void Main() {
            List<ExtendedCar1> cars1 = new List<ExtendedCar1>{
                new ExtendedCar1{Brand = "Audi", Model = "R8"},
                new ExtendedCar1{Brand = "Bentley", Model = "Azure"}
            };
            
            List<ExtendedCar2> cars2 = new List<ExtendedCar2>{
                new ExtendedCar2{Brand = "Ferrari", Color ="Red"},
                new ExtendedCar2{Brand = "Maruti", Color ="Saffire Blue"}
            };
            
            List<Car> cars = new List<Car>(cars1);
            cars.AddRange(cars2);
            
            foreach(var car in cars){
            	Console.WriteLine($"Car Brand: {car.Brand}");
            }
            
        }
        
    }
    
    
    public class Car{
       public String Brand {get;set;}    
    }
    
    public class ExtendedCar1 : Car {
       public String Model{get;set;}    
    }
    
    public class ExtendedCar2: Car {
       public String Color {get;set;}    
    }
