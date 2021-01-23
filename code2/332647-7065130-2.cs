            public bool Equals(Equipment other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }
                if (ReferenceEquals(this, other))
                {
                    return true;
                }
                return Equals(other.colour, colour) && other.cost == cost && other.serialNo == serialNo && Equals(other.type, type);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != typeof (Equipment))
                {
                    return false;
                }
                return Equals((Equipment) obj);
            }
    // note: if "Override the appropriate method to enable instances of this class
    // to be stored (and found) by key in a hash table" is supposed to mean that only type and
    // serialNo should be taken into account (since they are used to generate
    // the Key value) - just remove the lines with cost and colour
            public override int GetHashCode()
            {
                unchecked
                {
                    int result = (colour != null ? colour.GetHashCode() : 0);
                    result = (result*397) ^ cost.GetHashCode();
                    result = (result*397) ^ serialNo;
                    result = (result*397) ^ (type != null ? type.GetHashCode() : 0);
                    return result;
                }
            }
