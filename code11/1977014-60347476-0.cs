c#
public Button button1, button2, button3;
private void PrintName(GameObject cube) {
    if(cube.name.Equals("cube1") {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
    }
    if(cube.name.Equals("cube2") {
        button1.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);
    }
    if(cube.name.Equals("cube3") {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
    }
}
You need all buttons as Attributes for that. The buttons would just be the default ui buttons of unity.
