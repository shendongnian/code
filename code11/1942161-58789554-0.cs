cs
public abstract class Field : PictureBox {
	public Field() {
		Image = Image.FromFile(@"Bomb01.jpg");
		SizeMode = PictureBoxSizeMode.StretchImage;
		BorderStyle = BorderStyle.FixedSingle;
		Size = new Size(100, 100);
	}
	// ...
	// some abstract methods, not currently important
}
public class MemoryField : Field {
	public MemoryField(Form parent, int xPos, int yPos, int xSize, int ySize) {
		ClientSize = new Size(xSize, ySize);
		Location = new Point(xPos, yPos);
	}
	// ...
}
The real reason it was not working has to do with both *sizing* and *positioning* of each `Field` and their subcomponents. You should not set the `Location` of each `_pictureBox` relatively to its parent `MemoryField`, but rather change the `Location` of the `MemoryField` relatively to its parent `Form`.
You should also set the size of your `MemoryField` to the size of its child `_pictureBox` otherwise it won't size correctly to fit its content.
cs
public class MemoryField : Field {
	public MemoryField(Form parent, int xSize, int ySize) {
		_pictureBox.ClientSize = new Size(xSize, ySize);
		// I removed the setting of Location for the _pictureBox.
		this.Size = _pictureBox.ClientSize; // size container to its wrapped PictureBox
		this.Parent = parent; // not needed
	}
	// ...
}
and change your creation inner loop to
cs
for (int x = 0; x < 10; x++) // 10 columns
{
	Field field = new MemoryField(this,
		fieldWidth,
		fieldHeight);
	field.Location = new Point(x * (fieldWidth + 3), 0 + 0 + y * (fieldHeight + 3)); // Set the Location here instead!
	this.Controls.Add(field);
}
