     class AxisRoom
     {
         [JsonProperty("Extra Bed")]
         public decimal ExtraBed { get; set; }
     }
     AxisRoom _AxisRoom = new AxisRoom { ExtraBed = 3 };
     var result = JsonConvert.SerializeObject(_AxisRoom);
