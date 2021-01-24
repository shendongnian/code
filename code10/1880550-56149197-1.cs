       void Update()
       {
           if (!loadFirstFrame)
           {
               loadFirstFrame = true;
           }
           else if (loadFirstFrame)
           {
               if (!_startedPost)
               {
                   StartCoroutine(PostRequestBearerToken(APIHelpers.bearerString));
                   _startedPost = true;
               }         
               
               if (_postComplete)
                   SceneManager.LoadScene(2);
           }
       }
