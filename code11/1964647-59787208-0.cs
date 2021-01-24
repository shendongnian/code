    using System;
    using AutoMapper;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var config = new MapperConfiguration(cfg => 
    		{
    			cfg.CreateMap<StepUp, NuevoStepUpViewModel>()
    				.ForMember(vm => vm.TieneAuxiliar, opt => opt.MapFrom(e => e.auxValue.HasValue))
    				.ForMember(vm => vm.Example, opt => opt.MapFrom(e => e.Example))
    				.AfterMap((e, vm) => 
    						  {
    							  vm.CargaDatosElectricos.Example2 = e.Example2;
    						  });
    		});
    		
    		var mapper = config.CreateMapper();
    		
    		var stepUp = new StepUp()
    		{
    			Example = "Example 1",
    			Example2 = "Example 2",
    			auxValue = 10m
    		};
    		
    		var viewModel = mapper.Map<StepUp, NuevoStepUpViewModel>(stepUp);
    		
    		Console.WriteLine("SteUp was converted to ViewModel");
    		Console.WriteLine("TieneAuxiliar: {0}", viewModel.TieneAuxiliar);
    		Console.WriteLine("Example: {0}", viewModel.Example);
    		Console.WriteLine("CargaDatosElectricos.TieneAuxiliar: {0}", viewModel.CargaDatosElectricos.TieneAuxiliar);
    		Console.WriteLine("CargaDatosElectricos.Exemple2: {0}", viewModel.CargaDatosElectricos.Example2);
    		
    	}
    	
    	public class StepUp 
    	{
    		public string Example { get; set; }
    		public string Example2 { get; set; }
    		public decimal? auxValue { get; set; }
    	}
    	
    	public class NuevoStepUpViewModel
    	{
    		public bool TieneAuxiliar { get; set; }
    		public string Example { get;set; }
    		public CargaDatosElectricos CargaDatosElectricos { get; set; }
    		
    		public NuevoStepUpViewModel() 
    		{
    			this.CargaDatosElectricos = new CargaDatosElectricos();
    		}
    	}
    
    	public class CargaDatosElectricos 
    	{
    		public CargaDatosElectricos()
    		{
    		}
    		public bool TieneAuxiliar { get; set; }
    		public string Example2 { get; set; }
    	}
    }
