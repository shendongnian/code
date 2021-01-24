    using System.Linq;
    ...
    referenceToGenerator.Characters = referenceToGenerator.Characters.Where(c => c != null && c.enabled = true).ToList();
    var pickedCharacter = referenceToGenerator.Characters[Random.Range(0, referenceToGenerator.Characters.Count)];
    pickedCharacter.enabled = false;
    referenceToGenerator.Characters.Remove(pickedCharacter);
