    /// <summary>
    /// Inherit from interface <see cref="IEquatable{T}"/>
    /// </summary>
    public class Objeto : IEquatable<Objeto>
    {
        public string atributo1 { get; set; }
        public string atributo2 { get; set; }
    
        /// <summary>
        /// Implements <see cref="Equals(Objeto)"/> method from interface <see cref="IEquatable{T}"/>
        /// </summary>
        /// <param name="other">The second object we will compare.</param>
        /// <returns></returns>
        public bool Equals(Objeto other)
        {
            //If the object is null, are not equal.
            if(other==null)return false;
            //If isn't null we compare both attributes.
            return atributo1==other.atributo1&&atributo2==other.atributo2;
        }
    
        //Override Equals calling the Equals(Object) implementation.
        public override bool Equals(object obj) => Equals(obj as Objeto);
    
        //override GetHashCode making sure that if Equals is true, both objects must have the same HashCode.
        public override int GetHashCode()
        {
            return atributo1.GetHashCode() ^ atributo2.GetHashCode();
        }
    }
