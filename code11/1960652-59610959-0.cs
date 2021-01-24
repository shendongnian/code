public Color CircleFillColor { get => GetColor(CircleVertex); set => SetColor(CircleVertex, value); }
public Color SquareFillColor { get => GetColor(SquareVertex); set => SetColor(SquareVertex, value); }
public Color TriangleFillColor { get => GetColor(TriangleVertex); set => SetColor(TriangleVertex, value); }
private Vertex GetColor(Vertex vertex)
{
  return vertex.fillColor;
}
private void SetColor(Vertex vertex, Color color)
{
  vertex.fillColor = color;
}
