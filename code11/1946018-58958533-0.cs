    string qs;
    serverHub.On("flush", message => {
        qs = message;
        System.Console.WriteLine(message);
    });
