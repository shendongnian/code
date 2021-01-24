    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    				
    public class Program
    {
    	public static void Main()
    	{
    		string json=@"[{'id_factura':85,'fecha':'2019-08-07T19:00:00-05:00','cliente':{'persona_cedula_persona':'0705','tipocliente':{'id_tipo_cliente':1,'tipo_cliente':'PRUEBA'}},'lines':[{'id_detalle':30,'nombre_producto':'bidon de agua','cantidad':2,'precio':3},{'id_detalle':31,'nombre_producto':'botellas de agua','cantidad':12,'precio':7},{'id_detalle':32,'nombre_producto':'BOTELLA PEQUEÃ‘A','cantidad':5,'precio':3},{'id_detalle':33,'nombre_producto':'botella MEDIANA 5 LITROS','cantidad':12,'precio':7}]}]";
    		var Sresponse = JsonConvert.DeserializeObject<List<RootObject>>(json);
    		
    		foreach(var result in Sresponse)
    		{
    			//Get your data here from the deserialization
		    Console.WriteLine("Factura: "+result.id_factura);
			Console.WriteLine("Fecha: "+result.fecha);
			Console.WriteLine("Cliente Persona Cedula Persona: "+result.cliente.persona_cedula_persona);			
    		}
    
    	}
    }
    
    public class Tipocliente
    {
        public int id_tipo_cliente { get; set; }
        public string tipo_cliente { get; set; }
    }
    
    public class Cliente
    {
        public string persona_cedula_persona { get; set; }
        public Tipocliente tipocliente { get; set; }
    }
    
    public class Line
    {
        public int id_detalle { get; set; }
        public string nombre_producto { get; set; }
        public double cantidad { get; set; }
        public double precio { get; set; }
    }
    
    public class RootObject
    {
        public int id_factura { get; set; }
        public DateTime fecha { get; set; }
        public Cliente cliente { get; set; }
        public List<Line> lines { get; set; }
    }
