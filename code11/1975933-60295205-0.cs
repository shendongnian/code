     public string Name {get;set;}
     public int Age {get;set;}
     public List<ValuablesDTO> Valuables {get;set;}
     public  class ValuablesDTO
     {
          public string ItemName {get;set;}
          public decimal Quantity {get;set;}
          public decimal Cost {get;set;}
      }
}
