    public async Task GetBuilds() {
        	var data = new List < GetBuildTempClass > ();
        	var guids = new List < Guid > ();
        
        	using(var scope = _scopeFactory.CreateScope()) {
        		var _DBcontext = scope.ServiceProvider.GetRequiredService < PCFStatusContexts > ();
        
        		foreach(var app in data) {
        			var request = new HttpRequestMessage(HttpMethod.Get, "apps/" + app.AppGuid + "/builds?per_page=200&order_by=updated_at");
        			var response = await _client_SB.SendAsync(request);
        			var json = await response.Content.ReadAsStringAsync();
        			BuildsClass.BuildsRootObject model = JsonConvert.DeserializeObject < BuildsClass.BuildsRootObject > (json);
        
        			foreach(var item in model.resources) {
        				var x = _DBcontext.Builds.FirstOrDefault(o = >o.Guid == Guid.Parse(item.guid));
        
        				if (x == null) {
        					_DBcontext.Builds.Add(new Builds {
        						Guid = Guid.Parse(item.guid),
        						State = item.state,
        						CreatedAt = item.created_at,
        						UpdatedAt = item.updated_at,
        						Error = item.error,
        						CreatedByGuid = Guid.Parse(item.created_by.guid),
        						CreatedByName = item.created_by.name,
        						CreatedByEmail = item.created_by.email,
        						AppGuid = app.AppGuid,
        						AppName = app.AppName,
        						Foundation = 2,
        						Timestamp = DateTime.Now
        					});
        				}
        				else if (x.UpdatedAt != item.updated_at) {
        					x.State = item.state;
        					x.UpdatedAt = item.updated_at;
        					x.Timestamp = DateTime.Now;
        				}
        
        				guids.Add(Guid.Parse(item.guid));
        			}
        		}
        
        		var builds = _DBcontext.Builds.Where(o = >guids.Contains(o.Guid) == false && o.Foundation == 2 && o.DeletedAt == null);
        
        		foreach(var build_item in builds) {
        			build_item.DeletedAt = DateTime.Now;
        		}
        
        		await _DBcontext.SaveChangesAsync();
        	}
        }
