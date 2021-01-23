    interface IR<out T>
    {
        void D(T t);
    }
    class C : IR<Mammal>
    {
        public void D(Mammal m)
        {
            m.GrowHair();
        }
    }
    ...
    IR<Animal> x = new C(); 
    // legal because T is covariant and Mammal is convertible to Animal
    x.D(new Fish()); // legal because IR<Animal>.D takes an Animal
