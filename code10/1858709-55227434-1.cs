csharp
// [...]
        } while (temp != 0);
    }
} // <== this one closes the class, you should move it after all methods!
public void add_soda()
{
// [...]
    Console.WriteLine("Tryck för att återgå till menyn...");
}
} // <== this one closes the namespace, you should move it after the whole code!
public void print_crate()
{
// [...]
<br>
Also notice that you need a ```using sodacrate;``` to create a new object of Sodacrate in your Program class!
