    [HttpGet]
    		public JToken Get()
    		{
    			using (var conn = this.generalConfig.NewDbConnection)//just example db connection
    			{
    				var jObj = new JObject();
    				foreach (var setting in conn.GetAll<AppSetting>())
    				{
    					jObj[setting.AppSettingKey] = setting.AppSettingValue;
    				}
    				return jObj; //I'm returning the object to the client without restarting the app.
    			}
    		}
    		
    		[HttpPut]
    		public JToken Put([FromBody] JToken settings)
    		{
    			using (var conn = this.generalConfig.NewDbConnection) //example db
    			{
    				var currSettings = conn.GetAll<AppSetting>();
    				foreach (JProperty setting in settings)
    				{
    					var currSetting = currSettings.FirstOrDefault(c => c.AppSettingKey == setting.Name);
    					if (currSetting == null)
    					{
    						conn.Insert(new AppSetting { AppSettingKey = setting.Name, AppSettingValue = Convert.ToString(setting.Value) });
    					}
    					else
    					{
    						currSetting.AppSettingValue = Convert.ToString(setting.Value);
    						conn.Update(currSetting);
    					}
                        // adding or updating key value pair that is stored in db
    				}
    			}
    			return Get();
    		}
