    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    
    namespace controllertest
    {
        public class MyExampleBaseClass{
            public double value;
    }
        public abstract class Controller<T> : MyExampleBaseClass, IController<T>
        {
            public Queue<Controller<T>> registredcontrollers;
            public T master;
            public void wrapperfunction()
            {
                registredcontrollers = new Queue<Controller<T>>() { };
                this.master = getobj(this);
                registerController(this);
                _functionPreHook(this);
            }
    
            public void registerController(Controller<T> newController)
            {
                newController.master = master;
                newController.initialize();
                registredcontrollers.Enqueue(newController);
            }
    
            public abstract void initialize();
            public abstract void _functionPreHook(Controller<T> master);
            public abstract void functionwrapper(T master);
            public abstract T getobj(IController<T> master);
        }
    
        public abstract class AbstractControllerImplementation<T>:Controller<T>
        {
            public sealed override void _functionPreHook(Controller<T> master)
            {
                // iterate through the registred controllers dynamically:
                var enumerator = registredcontrollers.GetEnumerator();
                int position = -1;
                // enumerators start at index -1 so move to first element:
                enumerator.MoveNext();
                position++;
                // execute first element
                var currentController = enumerator.Current;
                currentController.functionwrapper(this.master);
                int length = registredcontrollers.Count;
                while (position < length)
                {
                    // since functionwrapper can modify the queue we have to get a new enumerator:
                    enumerator = registredcontrollers.GetEnumerator();
                    // advance itterator:
                    position++;
                    int newEnumPos = -1;
                    newEnumPos++;
                    enumerator.MoveNext();
                    while (newEnumPos < position && newEnumPos < length-1)
                    {
                        newEnumPos++;
                        enumerator.MoveNext();
                    }
                    // call functionwrapper:
                    currentController = enumerator.Current;
                    currentController.functionwrapper(this.master);
                    // adjust length
                    length = registredcontrollers.Count;
                }
            }
    
            public sealed override T getobj(IController<T> master)
            {
                return (T)master;
            }
    
            public void setAttr<T2>(string name, T obj, T2 value)
            {
                try
                {
                    obj.GetType().GetField(name).SetValue(obj, value);
                }
                catch
                {
                    this.GetType().GetField(name).SetValue(this, value);
                }
            }
    
            public void setAttrThisAndObj<T2>(string name, T obj, T2 value)
            {
                try
                {
                    obj.GetType().GetField(name).SetValue(obj, value);
                }
                catch
                {
                }
                try
                {
                    this.GetType().GetField(name).SetValue(this, value);
                }
                catch
                {
                }
            }
            
            public T2 getAttr<T2>(string name, T obj)
            {
                return (T2)obj.GetType().GetField(name).GetValue(obj);
            }
            public T2 getAttrElseSetDefault<T2>(string name, T obj, T2 preset)
            {
                try
                {
                    var res = getAttr<T2>(name, obj);
                    if (res != null) return res;
                    else setAttr(name, obj, preset);
                    return preset;
                }
                catch
                {
                    setAttr(name, obj, preset);
                    return preset;
                }
            }
            public T2 getAttrElseSetDefaultBoth<T2>(string name, T obj, T2 preset)
            {
                try
                {
                    var res = getAttr<T2>(name, obj);
                    if (res == null) res = preset;
                    this.GetType().GetField(name).SetValue(this,res);
                    return res;
                }
                catch
                {
                    this.GetType().GetField(name).SetValue(this, preset);
                    setAttr(name, obj, preset);
                    return preset;
                }
            }
        }
        public abstract class ControllerImplementation : AbstractControllerImplementation<ControllerImplementation>
        {
        }
        public class Selectable:ControllerImplementation
        {
            public bool isclicked;
            public bool isselected;
    
            public override void functionwrapper(ControllerImplementation master)
            {
                if (isSelected()) Console.WriteLine(">>> SELECTABLE FUNCTIONWRAPPER WAS CALLED!");
                if (isClicked()) Console.WriteLine("--- SELECTABLE IS CLICKED");
            }
    
            public override void initialize()
            {
                this.isclicked=getAttrElseSetDefault<bool>("isclicked", master, false);
                this.isselected = getAttrElseSetDefault<bool>("isselected", master, false);
                if(isSelected()) Console.WriteLine("INITIALIZING SELECTABLE!");
            }
            public bool isClicked()
            {
                try
                { 
                    return getAttr<bool>("isclicked", master);
                }
                catch
                {
                    return this.isclicked;
                }
            }
            public bool isSelected()
            {
                try
                {
                    return getAttr<bool>("isselected", master);
                }
                catch
                {
                    return this.isselected;
                }
            }
        }
    
        public class Controllable : Selectable
        {
            public bool canBeSelected;
            public bool canBeControlled;
            public override void functionwrapper(ControllerImplementation master)
            {
                if (isSelected()) Console.WriteLine(">>> CONTROLLABLE FUNCTIONWRAPPER WAS CALLED!");
                if (CanBeSelected()) {
                    if (isSelected()) Console.WriteLine("--- CONTROLLABLE IS SELECTABLE, REGISTERING COMPONENT!");
                    var s = new Selectable();
                    master.registerController(s);
                }
    
            }
            public override void initialize()
            {
                this.canBeSelected = getAttrElseSetDefault("canBeSelected", master, true);
                this.canBeControlled = getAttrElseSetDefault("canBeControlled", master, true);
                if (isSelected()) Console.WriteLine("INITIALIZING CONTROLLABLE!");
            }
            public bool CanBeSelected()
            {
                try
                {
                    return getAttr<bool>("canBeSelected", master);
                }
                catch
                {
                    return this.canBeSelected;
                }
            }
            public bool CanBeControlled()
            {
                try
                {
                    return getAttr<bool>("canBeControlled", master);
                }
                catch
                {
                    return this.canBeControlled;
                }
            }
        }
        public class presetMaskExample : Controllable
        {
            public override void initialize()
            {
                if (isSelected()) Console.WriteLine("INITIALIZING PRINTSTUFF");
                if (isSelected()) Console.WriteLine("setting canBeControlled and canBeSelected to true");
                setAttrThisAndObj("canBeSelected", master, true);
                setAttrThisAndObj("canBeControlled", master, true);
            }
        }
        public class PrintStuff : presetMaskExample
        {
            public string printstuff;
            public override void functionwrapper(ControllerImplementation master)
            {
                if (isSelected()) Console.WriteLine(">>> PRINTSTUFF FUNCTIONWRAPPER WAS CALLED!");
                if (CanBeControlled())
                {
                    if (isSelected()) Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>> PRINTSTUFF CAN BE CONTROLLED!");
                    Console.WriteLine(this.printstuff);
                }
            }
            public override void initialize()
            {
                if (isSelected()) Console.WriteLine("INITIALIZING P_PRINTSTUFF");
                var mask = new presetMaskExample();
                master.registerController(mask);
                if(printstuff==null) printstuff = getAttrElseSetDefaultBoth("printstuff", master, "LALALALALA!!!");
            }
        }
    
        public class PrintMe : ControllerImplementation
        {
            public bool allowOthersToPrint;
            private Dictionary<string, string> values;
            public override void functionwrapper(ControllerImplementation master)
            {
                Console.WriteLine(">>> PRINT_ME FUNCTIONWRAPPER WAS CALLED!");
                if (AllowOthersToPrint())
                {
                    foreach(KeyValuePair<string,string> kvp in values)
                    {
                        var i = new PrintStuff();
                        i.printstuff=(kvp.Key + "   |    " + kvp.Value);
                        i.canBeControlled = true;
                        master.registerController(i);
                    }
                }
                
            }
    
            public override void initialize()
            {
                values = new Dictionary<string, string>();
                Random rng = new Random();
                for (int i = 0; i < 15; i++)
                {
                    bool succeded = false;
                    var keybuffer = new byte[7];
                    var valuebuffer = new byte[55];
                    while (!succeded)
                    {
                        succeded = true;
                        rng.NextBytes(keybuffer);
                        rng.NextBytes(keybuffer);
                        rng.NextBytes(valuebuffer);
                        rng.NextBytes(valuebuffer);
                        var k = new string(UTF8Encoding.UTF8.GetChars(keybuffer));
                        var v = new string(UTF32Encoding.UTF8.GetChars(valuebuffer));
                        try
                        {
                            values.Add(k, v);
                        }
                        catch
                        {
                            succeded = false;
                        }
                    }
                    
                }
            }
            public bool AllowOthersToPrint()
            {
                try
                {
                    return getAttr<bool>("allowOthersToPrint", master);
                }
                catch
                {
                    return this.allowOthersToPrint;
                }
            }
        }
    }
