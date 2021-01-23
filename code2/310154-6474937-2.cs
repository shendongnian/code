    void button1_Click() {
        form2 = new Form2(() => textBoxName.Text);
    }
    class Form2 : Form {
        ...
        public Form2(Func<String> nameResolver) {
            form3 = new Form3(nameResolver);
        }
        void button1_Click(...) {
           form3.Show()
        }
    }
    class Form3 : Form {
        Func<String> nameResolver;
        
        public Form3(Func<string> nameResolver) {
            this.nameResolver = nameResolver;
        }
        void button1_Click(...) {
            this.textBoxName = nameResolver.Invoke();
        }
    }
