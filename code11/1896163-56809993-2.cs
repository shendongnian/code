    public override bool Equals(object obj)
    {
        return obj is B other
            && this.Prop.SequenceEqual(other.Prop) // will re-use A.Equals
            && this.Prop.GetType() == other.Prop.GetType() // not needed if different IReadOnlyList types are ok
            && this.GetType() == other.GetType(); // not needed if B is sealed
    }
I renamed `B.Prop` `CollectionProp` to avoid confusion. Considering that this property has an interface type you can additionally compare their type if they can be different.
4. `B.GetHashCode`:
You can aggregate the hash codes of `A` instances. Here I use a simple XOR but if the same items can often come in a different order you can come up with something more fancy.
 
    return Prop.Aggregate(0, (h, i) => h ^ i.GetHashCode());
