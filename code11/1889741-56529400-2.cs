           //Interface should be in its own file. 
	   public interface IPhoneNR{
			String getOwnerNumber();
	   }
	   
	   //assembly, register dependency
	   [assembly: Dependency (typeof (PhoneNr))]
	   namespace AndroidAppPCL
	   {
			public class PhoneNr : IPhoneNR
			{       
			public string ownNumber;
				protected String getOwnerNumber()
				{
					var telephonyManager = (TelephonyManager)this.ApplicationContext.GetSystemService(Context.TelephonyService);               
					return telephonyManager.Line1Number; 
				}             
			}
		}
		
		//Use in code PCL
		private void Btn_Clicked(object sender, EventArgs e)
		{
			if(Device.RuntimePlatform == Device.Android){
				label.txt = DependencyService.Get<IPhoneNR>().getOwnerNumber();
			}
		}
