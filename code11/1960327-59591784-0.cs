new List<string>(images)
List<string> images = new List<string>
{
     "1",
     "2",
     "3"
};
Message messageA = new Message(objet, rtfMessage, new List<string>(images), date_de_publication, texteEtat, couleurEtat);
// messageA.images = 1 , 2 , 3
images.Clear();
// messageA.images = new List<string>()
