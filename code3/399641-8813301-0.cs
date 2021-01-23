    void SayHelloXTimes(params string[] list) {
        for(int i = 0;i<list.Length;i++) {
            print(list[i])
        }
    }
    SayHelloXTimes("Hi", "Hi", "Hi"); // legal
    SayHelloXTimes("Hi"); // legal
    SayHelloXTimes("Hi", "Hi", "Hi", "Hi", "Hi", "Hi"); // still legal
