    var a = Observable.Range(1, 10);
    var b = Observable.Range(5, 10);
                
    var joinedStream = a.Join(b, _ => Observable.Never<Unit>(), _ => Observable.Never<Unit>(), 
        (aOutput, bOutput) => new Tuple<int, int>(aOutput,  bOutput))
        .Where(tupple => tupple.Item1 == tupple.Item2);
    
    joinedStream.Subscribe(output => Trace.WriteLine(output));
