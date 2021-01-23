    var stack = new Stack<int>();
    var program = new[] 
    { 
        OpCode.Ldc_3,
        OpCode.Ldc_6,
        OpCode.Ldc_2,
        OpCode.Sub,
        OpCode.Add,
    };
    for (int i = 0; i < program.Length; i++)
    {
        int a, b;
        switch (program[i])
        {
        case OpCode.Add: b = stack.Pop(); a = stack.Pop(); stack.Push(a + b); break;
        case OpCode.Sub: b = stack.Pop(); a = stack.Pop(); stack.Push(a - b); break;
        case OpCode.Mul: b = stack.Pop(); a = stack.Pop(); stack.Push(a * b); break;
        case OpCode.Div: b = stack.Pop(); a = stack.Pop(); stack.Push(a / b); break;
        case OpCode.Ldc_0: stack.Push(0); break;
        case OpCode.Ldc_1: stack.Push(1); break;
        case OpCode.Ldc_2: stack.Push(2); break;
        case OpCode.Ldc_3: stack.Push(3); break;
        case OpCode.Ldc_4: stack.Push(4); break;
        case OpCode.Ldc_5: stack.Push(5); break;
        case OpCode.Ldc_6: stack.Push(6); break;
        case OpCode.Ldc_7: stack.Push(7); break;
        case OpCode.Ldc_8: stack.Push(8); break;
        }
    }
    var result = stack.Pop();
