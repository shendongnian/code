    // Instance or static holder that won't get garbage collected (thanks chuu)
    System.Threading.Timer t;
    // Then when you need to delay something
    var t = new System.Threading.Timer(o =>
                {
                    _connection.Start(); 
                },
                null,
                TimeSpan.FromSeconds(15),
                TimeSpan.FromMilliseconds(-1));
