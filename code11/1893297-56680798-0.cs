C#
TextureTarget[] tragets = 
{
   TextureTarget.TextureCubeMapNegativeX, TextureTarget.TextureCubeMapNegativeY,
   TextureTarget.TextureCubeMapNegativeZ, TextureTarget.TextureCubeMapPositiveX,
   TextureTarget.TextureCubeMapPositiveY, TextureTarget.TextureCubeMapPositiveZ
} 
for (int i = 0; i < imagePaths.Count; i++)
{
    // Load the image
    using (var image = new Bitmap(imagePaths[i]))
    {
        Debug.WriteLine(imagePaths[i]);
        var data = image.LockBits(
            new Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadOnly,
            System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        GL.TexImage2D(tragets[i], // <------
            0,
            PixelInternalFormat.Rgb,
            image.Width,
            image.Height,
            0,
            PixelFormat.Rgb,
            PixelType.UnsignedByte,
            data.Scan0);
    }
}
---
The buffer object and vertex array object is created in every frame. Create the objects once at initialization and use it in every frame. Note, you dont' delete the objects, the GPU has no "garbage collection".
Do the [Vertex Specification](https://www.khronos.org/opengl/wiki/Vertex_Specification) in  `MainWindow.SetupGLControl`. It is sufficient to bind the [Vertex Array Object](https://www.khronos.org/opengl/wiki/Vertex_Specification#Vertex_Array_Object) before the draw call:
c#
public partial class MainWindow : Window
{
    private TextureCubemap cubemap;
    // [...]
    private void SetupGLControl()
    {
        // [...]
        cubemap = new TextureCubemap(ImageFaces);
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        _vertexArrayObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexArrayObject);
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        
        var vertexLocation = shader.GetAttribLocation("aPos");
        GL.EnableVertexAttribArray(vertexLocation);
        GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        //GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        // [...]
    }
    private void GlControl_Paint(object sender, PaintEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        cubemap.UseCubemap();
        shader.Use();
        shader.SetMatrix4("view", camera.GetViewMatrix());
        shader.SetMatrix4("projection", camera.GetProjectionMatrix());
        GL.BindVertexArray(_vertexArrayObject); // <------ bind vertex array object
        GL.DrawArrays(PrimitiveType.Triangles, 0, 36);
        glControl.SwapBuffers();
    }
    // [...]
}
``´
