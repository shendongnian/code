    Html.X().ID("testID")
    .Listeners
    (
	    l =>
	    {
		    l.AfterRender.Handler = @"App.testID.on('testEvent', function(id) {
																				 Ext.net.directRequest({
																					url: '/TestController/TestMethod',
																					extraParams:
																					{
																						'objectId': id
																					}
																				});
																			});";
	    }
    )
