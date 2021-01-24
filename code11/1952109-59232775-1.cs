c#
IEnumerable<object?>? maybeListOfMaybeItems = new object[] { 1, 2, 3 };
// inferred as IEnumerable<object?>
var listOfMaybeItems = maybeListOfMaybeItems!;
// no warning given, because ! supresses nullability warnings
IEnumerable<object> listOfItems = maybeListOfMaybeItems!;
// warning about the generic type change, since this line does not have !
IEnumerable<object> listOfItems2 = listOfMaybeItems;
