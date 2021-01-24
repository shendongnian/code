import QtQuick 2.6
import QtQuick.Controls 2.1
import QtQuick.Controls 1.4
import Features 1.0
Page {
    Pane {
        id: detsPane
        anchors.fill: parent
        contentHeight: pane.implicitHeight
        TableView {
            id: personTable
            implicitWidth:  pane.width -20
            
            TableViewColumn { 
                role: "id"
                title: "Identifier"
            }
            TableViewColumn {
                role: "name"
                title: "Name"
            }
    
            model: personModel
        }
        PersonModel {
            id: personModel
            Component.onCompleted: {
                personTable.model = Net.toListModel(personModel.personList) 
            }
        }
    }    
}
PersonModel.cs
--------------
using System.Collections.Generic;
namespace GUI.Models
{
    public class PersonModel 
    {
        public class Person
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public List<Person> PersonList { get; } = new List<Person>()
        {
            new Person(){Id="BB", Name="Bob Bobber" },
            new Person(){Id="RM", Name="Rod McRod" }
        };
    }
}
This will produce the following:
[![Application Screenshot][1]][1]
Nb. the qml page has been added to the example project from the project page. `Main.qml`:
    Drawer {
...        
            model: ListModel {
                ListElement { title: "Contacts"; source: "pages/PersonPage.qml" }
            }
...
    }
Also assumes that you have registered your model in `Program.cs`
   Qml.Net.Qml.RegisterType<PersonModel>("Features");
  [1]: https://i.stack.imgur.com/21Zp2.png
