	using System;
	using System.Collections.Generic;
	using UnityEngine;
	public class Example : MonoBehaviour
	{
		private void Start()
		{
			Item item = new Item("Albino Goat");
			SaveManager saveMgr = new SaveManager(new List<Animal>() { new Animal("Albino Goat") });
			Paddock specificPaddock = new Paddock();
			Animal animal = saveMgr.Remove(item.Name);
			specificPaddock.Add(animal);
			//UpdateStatOnAnimalAddEvent(onePercent);
		}
		private class SaveManager
		{
			private List<Animal> animals = null;
			public SaveManager(List<Animal> animals)
			{
				this.animals = animals ?? throw new ArgumentNullException(nameof(animals));
			}
			public Animal Remove(string animalName)
			{
				Predicate<Animal> match = (x) => x.Name.Equals(animalName);
				if (animals.Exists(match))
				{
					return animals.Find(match);
				}
				return null;
			}
		}
		private struct Item
		{
			public string Name { get; private set; }
			public Item(string name)
			{
				Name = name ?? throw new ArgumentNullException(nameof(name));
			}
		}
		private class Animal
		{
			public string Name { get; private set; }
			public Animal(string name)
			{
				Name = name ?? throw new ArgumentNullException(nameof(name));
			}
		}
		private class Paddock
		{
			private List<Animal> animals = null;
			public Paddock()
			{
				animals = new List<Animal>();
			}
			public void Add(Animal animal)
			{
				animals.Add(animal);
				Debug.LogFormat("Animal count in Paddock : {0}", animals.Count);
			}
		}
	}
