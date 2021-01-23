    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace BadFloat
    {
        class Program
        {
            static void Main(string[] args)
            {
                Currency yourMoneyAccumulator = 0.0d;
                int count = 200000;
                double increment = 20000.01d; //1 cent
                for (int i = 0; i < count; i++)
                    yourMoneyAccumulator += increment;
                Console.WriteLine(yourMoneyAccumulator + " accumulated vs. " + increment * count + " expected");
            }
        }
    
        struct Currency
        {
            private const double EPSILON = 0.00005;
            public Currency(double value) { this.value = value; }
            private double value;
            public static Currency operator +(Currency a, Currency b) { return new Currency(a.value + b.value); }
            public static Currency operator -(Currency a, Currency b) { return new Currency(a.value - b.value); }
            public static Currency operator *(Currency a, double factor) { return new Currency(a.value * factor); }
            public static Currency operator *(double factor, Currency a) { return new Currency(a.value * factor); }
            public static Currency operator /(Currency a, double factor) { return new Currency(a.value / factor); }
            public static Currency operator /(double factor, Currency a) { return new Currency(a.value / factor); }
            public static explicit operator double(Currency c) { return System.Math.Round(c.value, 4); }
            public static implicit operator Currency(double d) { return new Currency(d); }
            public static bool operator <(Currency a, Currency b) { return (a.value - b.value) < -EPSILON; }
            public static bool operator >(Currency a, Currency b) { return (a.value - b.value) > +EPSILON; }
            public static bool operator <=(Currency a, Currency b) { return (a.value - b.value) <= +EPSILON; }
            public static bool operator >=(Currency a, Currency b) { return (a.value - b.value) >= -EPSILON; }
            public static bool operator !=(Currency a, Currency b) { return Math.Abs(a.value - b.value) <= EPSILON; }
            public static bool operator ==(Currency a, Currency b) { return Math.Abs(a.value - b.value) > EPSILON; }
            public bool Equals(Currency other) { return this == other; }
            public override int GetHashCode() { return ((double)this).GetHashCode(); }
            public override bool Equals(object other) { return other is Currency && this.Equals((Currency)other); }
            public override string ToString() { return this.value.ToString("C4"); }
        }
    
    }
