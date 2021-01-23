    using namespace System;
    
    ref class Foo {
    
    private:
    	Action ^bar;
    
    public:
    	event Action ^Bar {
    		void add (Action ^action)
    		{
    			Console::WriteLine ("add");
    			bar += action;
    		}
    
    		void remove (Action ^action)
    		{
    			Console::WriteLine ("remove");
    			bar -= action;
    		}
    
    		void raise ()
    		{
    			Console::WriteLine ("raise");
    
    			if (!bar)
    				return;
    
    			Console::WriteLine ("raise for real");
    			bar->Invoke ();
    		}
    	};
    };
    
    void hello ()
    {
    	Console::WriteLine ("hello");
    }
    
    void main ()
    {
    	Foo ^foo = gcnew Foo ();
    	foo->Bar ();
    
    	foo->Bar += gcnew Action (&hello);
    
    	foo->Bar ();
    }
