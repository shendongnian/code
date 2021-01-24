struct Span2D<Type: IComparable> {
    Type MinX { get; };
    Type MaxX { get; };
    ...
}
public Span2D<Type> operator+(Span2D<Type> A, Span2D<Type> B) {
    Type minX = A.MinX < B.MinX ? A.MinX : B.MinX; // as normal...
}
