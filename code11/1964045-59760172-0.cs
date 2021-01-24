            private ObjectResult DeterminePositiveResponseType<T>(T response)
        {
            var methodType = HttpContext.Request.Method;
           
            switch (methodType)
            {
                case string m when HttpMethod.Get.ToString() == methodType:
                    return Ok(response);
                case string m when HttpMethod.Post.ToString() == methodType:
                    return Created("",response);
                default:
                    return Ok(response);
            }
        }
