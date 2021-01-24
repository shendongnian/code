using System;
public class A {
    public void Run() {
        Console.WriteLine("Foobar");
    }
}
Is completely equivalent in its effects, both in the CIL emitted as well as how users of `A` will use the class or derive it, to this code:
public class A {
    public void Run() {
        System.Console.WriteLine("Foobar");
    }
}
Let's say that we import a type that we return from a method:
using System.IO;
public class A {
    public Stream createStream() {
        // implementation irrelevant
    }
}
If we then declare `class B : A` in another source file, the `createStream()` method is inherited, and it _still_ returns `System.IO.Stream`, _even if the source file `B` is declared in doesn't have `using System.IO`_, and users of class `B` do not need to import `System.IO` in order to use the stream returned by `createStream()`; the system knows the fully-qualified type is `System.IO.Stream`.
public class B : A {
    public void doSomethingWithStream() {
        // We can use a System.IO.Stream object without importing System.IO
        using (var s = createStream()) {
        }
    }
}
public class C {
    public static void doSomethingElseWithStream(B b) {
        // As can other stuff that uses B.
        using (var s = b.createStream()) {
        }
    }
}
