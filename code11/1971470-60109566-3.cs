    services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.RequireHttpsMetadata = false;
                        options.Audience = "api1";
                        options.Events=new JwtBearerEvents(){
                            OnMessageReceived  =context=>{
                                var header =context.Request.Headers["Authorization"];
                                //Your validation logic here
                                //if validate failed
                                //{                           
                                //context.Response.StatusCode=401; 
                                //}                          
                                return Task.CompletedTask;
                            }
                        };
                    });
