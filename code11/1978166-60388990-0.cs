    using System;
    namespace Ticks {
        /// <summary>
        /// Allows allocation-free creation of an <see cref="ITick"/>, but is inefficient to pass from method to method because it is large.
        /// </summary>
        public readonly ref struct Tick {
            public static Tick Empty => new Tick(0, 0, 0, 0, DateTime.MinValue);
            public bool IsEmpty => Price == 0;
            public double Price { get; }
            public double Bid { get; }
            public double Ask { get; }
            public double Volume { get; }
            public DateTime TimeStamp { get; }
            public Tick(double price, double bid, double ask, double volume, DateTime timeStamp) {
                Price = price;
                Bid = bid;
                Ask = ask;
                Volume = volume;
                TimeStamp = timeStamp;
            }
        }
        /// <summary>
        /// Also allows allocation-free creation of an <see cref="ITick"/>, but this is efficient to pass from method to method because it is small,
        /// containing only a single pointer.
        /// It requires a <see cref="Tick"/> to be created once and guaranteed "pinned" to a location on the stack.
        /// </summary>
        public unsafe readonly ref struct TickPointer {
            readonly Tick* Ptr;
            public bool IsEmpty => Ptr->IsEmpty;
            public double Price => Ptr->Price;
            public double Bid => Ptr->Bid;
            public double Ask => Ptr->Ask;
            public double Volume => Ptr->Volume;
            public DateTime TimeStamp => Ptr->TimeStamp;
            public TickPointer(Tick* ptr) {
                Ptr = ptr;
            }
        }
        /// <summary>
        /// A reference-type implementation of the tick data for tests involving allocations.
        /// </summary>
        sealed class AllocatedTick {
            public readonly double Price;
            public readonly double Bid;
            public readonly double Ask;
            public readonly double Volume;
            public readonly DateTime TimeStamp;
            public AllocatedTick(double price, double bid, double ask, double volume, DateTime timeStamp) {
                Price = price;
                Bid = bid;
                Ask = ask;
                Volume = volume;
                TimeStamp = timeStamp;
            }
        }
    }
