Make sure that you have overridden the ToString method in your SampleData class like below:
				public class SampleData
{
								// This is just a sample property. you should replace it with your own properties.
								public string Name { get; set; }
								public override string ToString()
								{
								    // concat all the properties you wish to return as the string representation of this object.
								    return Name;
								}
}
Now instead of the following line,
    string selectedDCXText = (string)(lbselected.Items[i]); 
you should use:
    string selectedDCXText = lbselected.Items[i].ToString();
Unless you have ToString method overridden in your class, the ToString method will only output class qualified name E.G. "Sample.SampleData"
