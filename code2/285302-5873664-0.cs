    void Method(IEnumerable<Student> students, int age) {
      var c = new Closure() { Age = age };
      var filtered = students.Where(c.WhereDelegate);
      ...
    }
    class Closure {
      public int age;
      bool WhereDelegate(Student s) {
        return s.Age == age;
      }
    }
