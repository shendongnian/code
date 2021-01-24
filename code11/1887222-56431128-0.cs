                Get("/favoriteNumber0/{value:int}", (Func<dynamic, object>)FavoriteNumberObject);
                Get("/favoriteNumber1/{value:int}", arg => FavoriteNumber(arg));
                Get("/favoriteNumber2/{value:int}", FavoriteNumberTask);
                Get("/favoriteNumber3/{value:int}", FavoriteNumberTaskCt);
            ...
            private object FavoriteNumberObject(dynamic parameters)
            {
                return "So your favorite number is " + parameters.value + "?";
            }
            private string FavoriteNumber(dynamic parameters)
            {
                return "So your favorite number is " + parameters.value + "?";
            }
            private Task<string> FavoriteNumberTask(dynamic parameters)
            {
                return Task.FromResult("So your favorite number is " + parameters["value"] + "?");
            }
            private Task<string> FavoriteNumberTaskCt(dynamic parameters, CancellationToken ctx)
            {
                return Task.FromResult("So your favorite number is " + parameters["value"] + "?");
            }
