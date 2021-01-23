    1. invokeService(service1, ...) will check if service1 is enabled
    
    1.1. if service1 is enabled 
    1.1.1. callService(service1, ...)
    1.1.2. append the retrieved data to cookieData
    1.1.3. call the callback (i.e. go to 2.)
    1.2. if service1 is not enabled 
    1.2.1. call the callback (i.e. go to 2.)
    
    2. invokeService(service2, ...) will check if service2 is enabled
    2.1. if service2 is enabled 
    2.1.1. callService(service2, ...)
    2.1.2. append the retrieved data to cookieData
    2.1.3. call the callback (i.e. go to 3.)
    2.2. if service2 is not enabled 
    2.2.1. call the callback (i.e. go to 3.)
    
    3. invokeService(service3, ...) will check if service3 is enabled
    3.1. if service3 is enabled 
    3.1.1. callService(service3, ...)
    3.1.2. append the retrieved data to cookieData
    3.1.3. call the callback (i.e. go to 4.)
    3.2. if service3 is not enabled 
    3.2.1. call the callback (i.e. go to 4.)
    
    4. set the cookie content
