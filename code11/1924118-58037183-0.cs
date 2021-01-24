    public struct RGB<T>
    where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
      public T R { get; }
      public T G { get; }
      public T B { get; }
      public RGB(T r, T g, T b)
      {
        R = r;
        G = g;
        B = b;
      }
    }
    public class RGBComputeBuffer<T>
    where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
      public int Count { get; private set; }
      private RGB<T>[] _buffer;
      public RGBComputeBuffer(int count)
      {
        _buffer = new RGB<T>[count];
      }
      public RGB<T> this[int i]
      {
        get { return _buffer[i]; }
        set { _buffer[i] = value; }
      }
      public void Initialize(RGB<T> value)
      {
        for ( int i = 0; i < Count; i++ )
          _buffer[i] = value;
      }
      public void SetData(RGB<T>[] data)
      {
        Array.Resize(ref _buffer, data.Length);
        Count = data.Length;
        for ( int i = 0; i < data.Length; i++ )
          _buffer[i] = data[i];
      }
      public void GetData(RGB<T>[] data)
      {
        Array.Resize(ref data, _buffer.Length);
        for ( int i = 0; i < data.Length; i++ )
          data[i] = _buffer[i];
      }
      public void Clear()
      {
        _buffer = new RGB<T>[Count];
      }
    }
