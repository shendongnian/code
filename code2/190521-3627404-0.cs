    // Along with the existing using directives
    using System.Collections;
    ...
    // In the implementing class
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
